import React, { useState } from "react";
import './Feedback.css'

export default function Feedback() {
  // State to manage feedback value
  const [feedback, setFeedback] = useState(null);

  // Event handler for selecting feedback
  const handleFeedbackChange = (e) => {
    setFeedback(parseInt(e.target.value));
  };

  return (

<div className="container_f d-flex justify-content-center">
  <div className="card mt-5 pb-5">
    <div className="d-flex flex-row justify-content-between p-3 adiv text-white">

        <i className="fa fa-chevron-left"></i>
        <span className="pb-3">feedback</span>
        <i className="fa fa-times"></i>


    
    <div className="mt-2 p-4 text-center">
          <h6 className="mb-0">Your feedback helps us to improve.</h6>
          <small className="px-3">Please let us know about your chat experience.</small>
         
      <div className="container_f d-flex justify-content-center ">
        
      <div className="item">
          <label htmlFor="4">
            <input className="radio" type="radio" name="feedback" id="4" value="4" checked={feedback === 4} onChange={handleFeedbackChange}
            />
            <span>😍</span><br/>
          </label>
          </div>
          
          <div className="item">
          <label htmlFor="3">
            <input className="radio" type="radio" name="feedback" id="3" value="3" checked={feedback === 3} onChange={handleFeedbackChange}
            />
            <span>😁</span>
          </label>
        </div>

        <div className="item">
          <label htmlFor="2">
            <input className="radio" type="radio" name="feedback" id="2" value="2" checked={feedback === 2} onChange={handleFeedbackChange}
            />
            <span>😶</span>
          </label>
        </div>

        <div className="item">
          <label htmlFor="1">
            <input className="radio" type="radio" name="feedback" id="1" value="1" checked={feedback === 1} onChange={handleFeedbackChange}
            />
            <span>🙁</span>
          </label>
        </div>
      
          <div className="item">
          <label htmlFor="0">
            <input className="radio" type="radio" name="feedback" id="0" value="0" checked={feedback === 0} onChange={handleFeedbackChange}
            />
            <span>🤬</span>
          </label>
        </div>
          
          <div className="container_f d-flex justify-content-center">
         <div className="container_f d-flex justify-content-center">
            <textarea className="form-control" rows="4" placeholder="Message"></textarea>
          </div>
          <div className="mt-2">
            <button type="button" className="btn btn-primary btn-block"><span>Send feedback</span></button>
          </div>
        <p className="mt-3">Continue without sending feedback</p>
      </div>
        </div>
      </div>

      </div>
</div>
</div>  
  
  );
}


