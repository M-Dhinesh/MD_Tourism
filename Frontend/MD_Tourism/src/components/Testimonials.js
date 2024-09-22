import React from "react";
import styled from "styled-components";
import avatarImage from "../assets/avatarImage.jpeg";
export default function Testimonials() {
  return (
    <Section id="testimonials">
      <div className="title">
        <h2>Happy Customers</h2>
      </div>
      <div className="testimonials">
        <div className="testimonial">
          <p>
          Thank you so much for being proactive. Maybe it seems like no big deal to you but this is amazing customer service and is greatly appreciated.          </p>
          <div className="info">
            <img  src="https://i.ibb.co/3vMPgG7/narashimun.jpg" alt="" />
            <div className="details">
              <h4>Narasimhun</h4>
              <span>USA</span>
            </div>
          </div>
        </div>
        <div className="testimonial">
          <p>
          I highly recommend the Resort at Longboat Key & the area. It was perfect for not being crowded on the beach. The beach is for guests only & beautiful!
          </p>
          <div className="info">
            <img src="https://i.ibb.co/qknxVsX/karthi.jpg" alt="" />
            <div className="details">
              <h4>Karthiban</h4>
              <span>UK</span>
            </div>
          </div>
        </div>
        <div className="testimonial">
          <p>
          Booking through you was very easy and made our lives so much easier. I have nothing bad to say! Thank you for giving us tips and guidance it was very helpful!
          </p>
          <div className="info">
            < img src="https://i.ibb.co/yRp4J4P/dhinesh.jpg" alt="" />
            <div className="details">
              <h4>Dhinesh</h4>
              <span>Ukraine</span>
            </div>
          </div>
        </div>
      </div>
    </Section>
  );
}

const Section = styled.section`
  margin: 5rem 0;
  .title {
    text-align: center;
    margin-bottom: 2rem;
  }
  .testimonials {
    display: flex;
    justify-content: center;
    margin: 0 2rem;
    gap: 2rem;
    .testimonial {
      background-color: aliceblue;
      padding: 2rem;
      border-radius: 0.5rem;
      box-shadow: rgba(100, 100, 111, 0.2) 0px 7px 29px 0px;
      transition: 0.3s ease-in-out;
      &:hover {
        transform: translateX(0.4rem) translateY(-1rem);
        box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
      }
      .info {
        display: flex;
        justify-content: center;
        gap: 1rem;
        align-items: center;
        margin-top: 1rem;
        img {
          border-radius: 3rem;
          height: 3rem;
        }
        .details {
          span {
            font-size: 0.9rem;
          }
        }
      }
    }
  }
  @media screen and (min-width: 280px) and (max-width: 768px) {
    .testimonials {
      flex-direction: column;
      margin: 0;
      .testimonial {
        justify-content: center;
        .info {
          flex-direction: column;
          justify-content: center;
        }
      }
    }
  }
`;
