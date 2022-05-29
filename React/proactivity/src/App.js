import './App.css';
import { useState } from 'react';

let initialState =  [{
  "id" : 1,
  "description": "First Activity"
},
{
  "id" : 2,
  "description": "Second Activity"
},

];

function App() {
 

  const [activities, setActivities] = useState(initialState)

  function addActivity(e){
    // e.preventDefault() added for stop submit the form default
    e.preventDefault();

    const act = {
      id: document.getElementById('id').value,
      description: document.getElementById('description').value
    };
    // spred operator to add activity in array
    setActivities([...activities, {...act}]);
    console.log(activities);
  }
  
  return (
    <>
    <form className="row g-3">
        <div className="col-md-6">
          <label for="inputEmail4" className="form-label">Code</label>
          <input id="id" type="text" className="form-control"/>
        </div>
        <div className="col-md-6">
          <label for="inputEmail4" className="form-label">E-mail</label>
          <input id="description" type="text" className="form-control"/>
        </div>
         <div class="col-12">
            <button 
              className="btn btn-outline-secondary" 
              onClick={addActivity}>
              + Activity
            </button>
      </div>
    </form>
    <div className="App mt-3">
       
          {activities.map(act => (

        <div key={act.id}  className="card mb-2 shadow-sm">
          <div className="card-body">
            <h5 className="card-title">Card title</h5>
            <p className="card-text">
              <div className="d-flex.justfy-content-between">
                <h5 className="card-title">
                <span className="badge bg-secondary me-1">{act.id}</span>
                  - title
                </h5>
                <h6>
                Priority:
                <span className="ms-1 text-black">
                  <i className="me-1 fa-regular fa-face-meh"></i>
                  Normal
                </span>
                </h6>
              </div>
              {act.id} - {act.description}
            </p>
          </div>
        </div>
        ))}
        
    </div>
    </>
    );
  }
  
  export default App;
  