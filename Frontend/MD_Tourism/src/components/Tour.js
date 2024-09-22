import React from "react";
import { Container, Row, Col, Button } from "reactstrap";
import "../App.css";
//import tours from "../components/Package";

import imgCard1 from '../img/img-card (1).jpg';
import imgCard2 from "../img/img-card (2).jpg";
import imgCard3 from "../img/img-card (3).jpg";
import imgCard4 from "../img/img-card (4).jpg";

const Tour = () => (
  <div className="subComponent"> 
<>      
<section className="tour-cover item-center">
        <img src={imgCard1} alt="" />
        <h1>Seaside Resort</h1>
        <h4>Batangas Resort</h4>
      </section>
      <section className="tour-info">
     
        <Row>
          <Col sm="8">
            <div className="tour-desc">
              <p>
                Lorem ipsum dolor sit amet, consectetur adipiscing elit. In
                imperdiet, sem id vehicula lacinia, mi purus lacinia mauris,
                vitae mollis nisl elit in lorem. Suspendisse potenti. Cras
                elementum ullamcorper tortor, rutrum convallis nunc tempor
                tristique. Donec ut ipsum vel mauris hendrerit efficitur. Nullam
                eget massa interdum, euismod nunc ac, maximus risus. Aliquam nec
                rhoncus tortor. Suspendisse nulla diam, hendrerit a metus vitae,
                rutrum hendrerit nisl. Nulla vel venenatis massa. Mauris lacinia
                porttitor ex, a egestas nisi fringilla vitae. Nam fringilla leo
                ante, id interdum sapien facilisis vel. Morbi ut suscipit nulla.
                Sed vitae tempus elit, at laoreet urna.
              </p>
              <p>
                Morbi facilisis, odio vitae egestas pretium, mauris tortor
                vulputate dolor, non interdum nunc tellus at dolor. Donec
                condimentum et augue vitae volutpat. Fusce vitae laoreet sem.
                Integer a justo sit amet nibh vehicula blandit. Suspendisse
                faucibus venenatis egestas. In vulputate sapien sit amet ligula
                vulputate, in consequat ex molestie. Curabitur hendrerit
                pulvinar vehicula. Phasellus quis posuere tortor. Cras
                pellentesque vehicula dui nec fermentum. Sed venenatis nunc
                justo. Quisque metus est, volutpat quis scelerisque in,
                fermentum sed lacus. Sed sed pretium massa. Aenean imperdiet
                molestie turpis at egestas.
              </p>
            </div>
          </Col>
          <Col sm="4">
            <div className="tour-gallery">
              <a href={imgCard1}>
                <img src={imgCard1} alt="" />
              </a>
              <a href={imgCard2}>
                <img src={imgCard2} alt="" />
              </a>
              <a href={imgCard3}>
                <img src={imgCard3} alt="" />
              </a>
              <a href={imgCard4}>
                <img src={imgCard4} alt="" />
              </a>
            </div>
          </Col>
        </Row>
      </section>
      </>  


       <section className="reviews">
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
    </section>
  </div>
);

export default Tour;
