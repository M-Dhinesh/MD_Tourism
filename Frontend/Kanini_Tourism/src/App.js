import React, { useEffect } from "react";
import { Routes,Switch, Route, BrowserRouter } from "react-router-dom";
import scrollreveal from "scrollreveal";
import Home from './components/Home';
import Reg from './components/Reg';
import Log from './components/Log';
import Feedback from './components/Feedback';
import TravelerHome from "./components/TravelerHome";
import AfterLoginNavbar from "./components/AfterLoginNavbar";
import Packageform from "./components/PackageForm";
import Landing from "./components/Landing";
import UpdatePackage from "./components/UpdatePackage";
import ViewPackages from "./components/ViewPackages";
import Agent from "./components/Agent";

export default function App() {
  useEffect(() => {
    const sr = scrollreveal({
      origin: "top",
      distance: "80px",
      duration: 2000,
      reset: true,
    });
    sr.reveal(
      `
        nav,
        #hero,
        #services,
        #recommend,
        #testimonials,
        #Log
        footer
        `,
      {
        opacity: 0,
        interval: 300,
      }
    );
  }, []);
  return (
    <div>
      <BrowserRouter>
         <Routes>
           <Route path="/" exact element={<Landing/>} />
           <Route path="Home" element={<Home/>}/>
           <Route path="login" exact element={<Log/>} />
           <Route path="register" element={<Reg/>} />
           <Route path="feedback" element={<Feedback/>} />
           <Route path="Home" element={<TravelerHome/>} />
           <Route path="AfterLoginNavbar" element={<AfterLoginNavbar/>} />
           <Route path="Packageform" element={<Packageform/>} />
           <Route path="UpdatePackage" element={<UpdatePackage/>} />
           <Route path="ViewPackages" element={<ViewPackages/>} />
           <Route path="Agent" element={<Agent/>} />
         </Routes>
       </BrowserRouter>
    </div>
  );
}
