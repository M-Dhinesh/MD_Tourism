import React, { useState } from 'react';
import './Log.css';
import { useNavigate } from "react-router-dom";
import { MdEmail, MdLock } from 'react-icons/md';

// import ReactToastify from './node_modules/react-toastify/dist/react-toastify.esm.mjs';
// import { toast } from "react-toastify";
// import "react-toastify/dist/ReactToastify.css";

function Login()  {
  const [isSignUp, setIsSignUp] = useState(false);

  const handleSignUpClick = () => {
    setIsSignUp(true);
  };


  const navigate = useNavigate();
  const [loginData, setLoginData] = useState({
    "userId": 0,
    "email": "",
    "password": "",
    "role": "",
    "token": ""
  });

  const Log = () => {
    console.log(loginData);
    fetch("http://localhost:5299/api/Account/Login", {
      method: "POST",
      headers: {
        accept: "text/plain",
        "Content-Type": "application/json",
      },
      body: JSON.stringify({ ...loginData, "Login": {} }),
    })
      .then(async (data) => {
        navigate("/Home");
        var myData = await data.json();
        localStorage.setItem("id", myData.userId);
        localStorage.setItem("email", myData.email);
        localStorage.setItem("role", myData.role);
        localStorage.setItem("token", myData.token);
        if (myData.role === "Agent") {
          console.log(myData);
          // toast.success("successful");
          navigate("/ViewPackages");
        } else if (myData.role === "traveller") {
          console.log(myData);
          // toast.success("successful");
          navigate("/Home");
        } else if (myData.role === "Admin") {
          console.log(myData);
          // toast.success("successful");
          navigate("/Agent");
        }else if ((myData.role === "Traveller" || myData.role === "Agent")&& myData.token == null) {
          console.log(myData);
          // toast.warning("Oops!! It seems you are not yet approved . Try login later !!");
          navigate("/UnApproveProfile");
        } else if(myData.userId===0 && myData.password!==""){
          // toast.warning("Kindly Fill the User Id Field!!");
          alert.warning("Kindly Fill the User Id Field!!");
        }
        else if(myData.userId!==0 && myData.password===""){
          // toast.warning("Kindly Fill the Password Field!!");
          alert("Kindly Fill the Password Field!!");
        }
        else if(myData.userId===0 && myData.password===""){
          console.log(myData);
          //toast.warning("Kindly Fill all the fields !!");
          alert("Kindly Fill all the fields !!");
        }
      })
      .catch((err) => {
        //toast.error("Kindly check your User Id and Password !!");
        alert("Kindly check your User Id and Password !!");
        console.log(err.error);
      });
  };


  const handleSignInClick = () => {
    setIsSignUp(false);
  };

  return (
    <div className={`container ${isSignUp ? 'sign-up-mode' : ''}`}>
      <div className="forms-container">
        <div className="signin-signup">
          <form action="#" className="sign-in-form"> 
          <h2 className="title">Login</h2>
            <div className="input-field">
              <i className="fa fa-user"><MdEmail /></i>
              <input type="text" onChange={(event) => {
                setLoginData({
                  ...loginData,
                  email: event.target.value,
                  });}}
                placeholder="Email" />
            </div>
            <div className="input-field">
              <i className="fa fa-lock"> <MdLock /></i>
              <input type="password" onChange={(event) => {
                  setLoginData({
                    ...loginData,
                    password: event.target.value,
                    });}}
                placeholder="Password" />
            </div>
           

            <input onClick={Log} type="submit" value="Login" className="btn solid" />
          </form>
          <form action="#" className="sign-up-form">
          <h2 className="title">Forget Password</h2>

            <div className="input-field">
              <i className="fa fa-email"><MdEmail /></i>
              <input type="email" placeholder="Email" />
            </div>
            <div className="input-field">
              <i className="fa fa-lock"> <MdLock /></i>
              <input type="password" placeholder="Password" />
            </div>
            <div className="input-field">
              <i className="fa fa-lock"> <MdLock /></i>
              <input type="password" placeholder=" Confirm Password" />
            </div>

            <input type="submit" className="btn" value="update" />
          </form>
        </div>
      </div>
      <div className="panels-container">
        <div className="panel left-panel">
          <div className="content">

          <h3>Forget Password</h3>
            <p>
            Password & Journeys don't happen, you create them or update it !

            </p>


            <button className="btn transparent" id="sign-up-btn" onClick={handleSignUpClick}>
              change pwd
            </button>
          </div>

          <img
            src="https://raw.githubusercontent.com/sefyudem/Sliding-Sign-In-Sign-Up-Form/955c6482aeeb2f0e77c1f3c66354da3bc4d7a72d/img/register.svg"
            className="image"
            alt=""
          />
        </div>
        <div className="panel right-panel">
          <div className="content">

          <h3>One of us ?</h3>
            <p>
            It's never too late to be what you might have been, start your adventure !

            </p>
        
            <button className="btn transparent" id="sign-in-btn" onClick={handleSignInClick}>
              login
            </button>
          </div>

          <img
            src="https://raw.githubusercontent.com/sefyudem/Sliding-Sign-In-Sign-Up-Form/955c6482aeeb2f0e77c1f3c66354da3bc4d7a72d/img/log.svg"
            className="image"
            alt=""
          />
          

        </div>
      </div>
    </div>
  );
};

export default Login;
