import React, { Component } from "react";
import "../App.css";

import Contact from "../components/Contact";
import Package from "../components/Package";
import Around from "../components/Around";
import Top from "../components/Top";
import scrollreveal from "scrollreveal";
import ScrollToTop from "../components/ScrollToTop";



class Opening extends Component {
  render() {
    return (
      <div id='open'>

      <ScrollToTop />
      
      <Top/>
      <Around/>
      <Package/>
      <Contact/>


      </div>
    );
  }
}

export default Opening;
