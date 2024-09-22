// import './PackageForm.css'
import React, { useState } from 'react';
// import 'bootstrap/dist/css/bootstrap.min.css';
import { Button, Form, FormGroup, FormControl, FormLabel } from 'react-bootstrap';
import { useNavigate } from "react-router-dom";
import { Link } from "react-router-dom";

function Packageform(){
    const navigate = useNavigate();
    const [PackageData, setPackageData] = useState({
        "packageId": 0,
        "agencyId": 0,
        "destination": "",
        "departureCity": "",
        "fromDate": "2023-08-06T06:50:21.986Z",
        "toDate": "2023-08-06T06:50:21.986Z",
        "no_Days": 0,
        "no_Nights": 0,
        "foodIncluded": "",
        "accommodationIncluded": "",
        "tourType": "",
        "description": "",
        "available": 0,
        "price": 0,
        "places": ""
    });
  
    const Pack = () => {
      console.log(PackageData);
      fetch("http://localhost:5014/api/Package/AddPackage", {
        method: "POST",
        headers: {
          accept: "text/plain",
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ ...PackageData, "Package": {} }),
      })
        .then(async (data) => {
          navigate("/Home");
          var myData = await data.json();
          console.log(myData);
        //   localStorage.setItem("id", myData.userId);
        })
        .catch((err) => {
          //toast.error("Kindly check your User Id and Password !!");
          alert("Kindly check your User Id and Password !!");
          console.log(err.error);
        });
    };


  const [file, setFile] = useState(null);

  const handleFileChange = (e) => {
    const fileName = e.target.files[0].name;
    setFile(fileName);
  };

  const handleFileLabel = () => {
    if (file) {
      return file;
    }
    return 'Drag file here or click the above button';
  };

  return (
    <div className="t_container TA_card-0 justify-content-center">
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
      <div className="TA_card-body px-sm-4 px-0">
        <div className="row justify-content-center mb-5">
          <div className="col-md-10 col">
            <h3 className="font-weight-bold ml-md-0 mx-auto text-center text-sm-left">Traveller Form</h3>
            <p className="mt-md-4 ml-md-0 ml-2 text-center text-sm-left">
            we are offering Adventurs tours .
            </p>
          </div>
        </div>
        <div className="row justify-content-center round">
          <div className="col-lg-10 col-md-12">
            <div className="TA_card shadow-lg TA_card-1">
              <div className="TA_card-body inner-TA_card">
                <Form onSubmit={(e) => e.preventDefault()}>

                  <div className="row justify-content-center">
                  <div className="col-lg-5 col-md-6 col-sm-12">

                  <div className="form-group">
                      <label >Agency ID</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"agencyId":event.target.value})}}  type="number" className="form-control" id="Agency ID" placeholder="Agency ID" />
                    </div> 
                    
                    <div className="form-group">
                      <label >Destination </label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"destination":event.target.value})}} type="text" className="form-control" id="Destination" placeholder="Destination" />
                    </div> 
                    
                    <div className="form-group">
                      <label >Departure City </label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"departureCity":event.target.value})}} type="text" className="form-control" id="DepartureCity" placeholder="Departure City" />
                    </div> 

                    <div className="form-group">
                      <label >From Date</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"fromDate":event.target.value})}} type="Date" className="form-control" id="FromDate" placeholder="From Date" />
                    </div> 

                    <div className="form-group">
                      <label >To Date</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"toDate":event.target.value})}} type="Date" className="form-control" id="ToDate" placeholder="To Date" />
                    </div> 

                    <div className="form-group">
                      <label >Availablility</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"available":event.target.value})}} type="number" className="form-control" id="Availablility" placeholder="Availablility" />
                    </div>
                      
                    <div className="form-group">
                      <label >Description</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"description":event.target.value})}} type="text" className="form-control" id="Description" placeholder="Description" />
                    </div>
                
                  </div>

                  <div className="col-lg-5 col-md-6 col-sm-12">

                  <div className="form-group">
                      <label>Price</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"price":event.target.value})}} type="number" className="form-control" id="Price" placeholder="Price" />
                    </div>

                    <div className="form-group">
                      <label>Days </label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"no_Days":event.target.value})}} type="number" className="form-control" id="days" placeholder="Days" />
                    </div>

                    <div className="form-group">
                      <label>Nights </label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"no_Nights":event.target.value})}} type="number" className="form-control" id="Nights" placeholder="Nights" />
                    </div>
                   
                    <div className="form-group">
                      <label >Tour Type</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"tourType":event.target.value})}} type="text" className="form-control" id="TourType" placeholder="Tour Type" />
                    </div>

                    <div className="form-group">
                      <label >Food Accommodation</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"foodIncluded":event.target.value})}} type="text" className="form-control" id="FoodAccommodation" placeholder="Food Accommodation" />
                    </div>

                    <div className="form-group">
                      <label >Accommodation</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"accommodationIncluded":event.target.value})}} type="text" className="form-control" id="Accommodation" placeholder="Accommodation" />
                    </div>
                    <div className="form-group">
                      <label >Places</label>
                      <input onChange={(event)=>{setPackageData({...PackageData,"places":event.target.value})}} type="text" className="form-control" id="Places" placeholder="Places" />
                    </div>
              
                  </div>
                </div>

                  <div className="row justify-content-center">
                    <div className="col-md-12 col-lg-10 col-12">
                      <div className="form-group files">
                        <label className="my-auto">{handleFileLabel()}</label>
                        <input id="file" type="file" className="form-control" onChange={handleFileChange} />
                      </div>
                    </div>
                  </div>
                  <div className="row justify-content-center">
                    <div className="col-md-12 col-lg-10 col-12">
                      <div className="form-group">
                        <label >Message</label>
                        <textarea className="form-control rounded-0" id="exampleFormControlTextarea2" rows="5"></textarea>
                      </div>
                      <div className="row justify-content-end mb-5">
                        <div className="col-lg-4 col-auto">
                          <Button type="submit" variant="primary" className="btn-block">
                            <small className="font-weight-bold" onClick={Pack}>Request a Quote</small>
                          </Button>
                        </div>
                      </div>
                    </div>
                  </div>
                </Form>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default Packageform;