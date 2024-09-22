
import React from "react"
import {useState,useEffect} from "react";
import { Link } from "react-router-dom";

function ViewPackages(){
    const[Package,setPackages]=useState([
        {
            "packageId": 0,
            "agencyId": 0,
            "destination": "",
            "departureCity": "",
            "fromDate": "2023-08-06T08:06:15.463Z",
            "toDate": "2023-08-06T08:06:15.463Z",
            "no_Days": 0,
            "no_Nights": 0,
            "foodIncluded": "",
            "accommodationIncluded": "",
            "tourType": "",
            "description": "",
            "available": 0,
            "price": 0,
            "places": ""
        }]
    );
    const[IdDTO,setID]=useState({
        "id":0
    });
    const View = () => {
        console.log(IdDTO);
        fetch("http://localhost:5014/api/Package/GetPackageByAgentID", {
            method: "POST",
            headers: {
              accept: "text/plain",
              "Content-Type": "application/json"
            },
            body: JSON.stringify({ ...IdDTO, "IdDTO": {} })
          })
        .then(async (data)=>{
            if(data.status >= 200 && data.status<=300){
                console.log(IdDTO);
                var myData = await data.json();
                console.log(myData);
                setPackages(myData);
            }
        })
        .catch((err)=>{
            console.log(err.error)
        })
    };

    useEffect(() => {
        setID({...IdDTO,"id":localStorage.getItem("id")});
        View();
      }, [Package]);

return(
    <div>
        <div>
        <ul>
          <li>
        <Link to="/ViewPackages"><button>Packages</button></Link>
          </li>
          <li>
        <Link to="/UpdatePackage"><button>Update Package</button></Link>
          </li>
          <li>
          <Link to="/PackageForm"><button>Add Package</button></Link>
          </li>
        </ul>
        </div>
    <div>
        <h1 className="list-head">Packages</h1>
    <main>
    <table>
            <tr>
            <th>Package ID</th>
            <th>Destination</th>
            <th>Departure City</th>
            <th>From Date</th>
            <th>To Date</th>
            <th>Price</th>
            </tr>
            { Package.map((user) => (
                    <tr>
                <td>{user.packageId}</td>
                <td>{user.destination}</td>
                <td>{user.departureCity}</td>
                <td>{user.fromDate}</td>
                <td>{user.toDate}</td>
                <td>{user.price}</td>
             </tr>
            ))} 
    </table>
    </main>
    </div>
    </div>
);
}

export default ViewPackages;