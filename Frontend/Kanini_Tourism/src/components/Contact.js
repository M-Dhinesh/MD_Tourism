import React, { Component } from "react";
import { Container, Row, Col, Button } from "reactstrap";
import "../App.css";

class Contact extends Component {
  render() {
    return (
      <div className="subComponent-lg" id="contactBody">
    <div>      
      <header className="headerTitle text-center">
            <h1>Contact</h1>
            <p>GET IN TOUCH WITH US</p>
          </header>
          
          <hr />
          <br />
          <section className="msg text-center">
            <form action="">
              <Row>
                <Col sm="6">
                  <input
                    type="text"
                    name="Name"
                    id="reviewer-name"
                    placeholder="Your Name"
                    required
                  />
                  <br />
                  <input
                    type="email"
                    name="Email"
                    id="reviewer-email"
                    placeholder="Your email"
                    required
                  />
                </Col>
                <Col>
                  <textarea
                    name="Message"
                    id="reviewer-message"
                    rows="4"
                    placeholder="Your Message"
                  />
                  <Button outline color="light" className="float-left">
                    Send Message
                  </Button>
                </Col>
              </Row>
            </form>
          </section>
      </div>    
  </div>
    );
  }
}

export default Contact;
