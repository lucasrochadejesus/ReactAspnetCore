import './App.css';
import { useState } from 'react';

let initialState =  [{
  'id' : 1,
  'priority': '',
  'title': 'title 1',
  'description': 'First Activity'
}, 

];

function App() {
 

  const [activities, setActivities] = useState(initialState)

   // Function Add Activity
  function addActivity(e){
    // e.preventDefault() added for stop submit the form default
    e.preventDefault();

    const act = {
      id: document.getElementById('id').value,
      priority: document.getElementById('priority').value,
      title: document.getElementById('title').value,
      description: document.getElementById('description').value
    };
    // spred operator to add activity in array
    setActivities([...activities, {...act}]);
    console.log(activities);
  }

  function deleteActivity(id){
    
    const actFilter = activities.filter(act => act.id !== id);
    setActivities([... actFilter])
     
  }


  // Function Priority Values Label
  function priorityLabel(param){
    switch(param){
      case '1':
        return 'Low';
      case '2':
        return 'Medium';
      case '3':
        return 'High';
      default:
        return 'Not defined';
    }
  }

  function priorityStyle(param, icon){
    switch(param){
      case '1':
        return icon ? 'smile' : 'success';
      case '2':
        return icon ? 'meh' : 'warning';
      case '3':
        return icon ? 'angry' : 'danger';
      default:
        return 'meh';
    }
  }



  
  return (
    <>
    <form className='row g-3'>
        <div className='col-md-6'>
          <label className='form-label'>Id</label>
          <input id='id' type='text' className='form-control' 
          readOnly value={Math.max.apply(Math, activities.map(item => item.id)) + 1}
          />
        </div>
        <div className="col-md-6">
                <label className="form-label">Priority</label>
           <select id="priority" className="form-select">
               <option defaultValue="0">Choose an option</option>
               <option value="1">Low</option>
               <option value="2">Medium</option>
               <option value="3">High</option>
           </select>
        </div>
        <div className='col-md-6'>
          <label className='form-label'>Title</label>
          <input id='title' type='text' className='form-control'/>
        </div>
        <div className='col-md-6'>
          <label className='form-label'>Description</label>
          <input id='description' type='text' className='form-control'/>
        </div>
         <div className='col-12'>
            <button 
              className='btn btn-outline-secondary' 
              onClick={addActivity}>
              + Activity
            </button>
      </div>
    </form>
    <div className='mt-3'>
       
          {activities.map(act => (
        <div key={act.id}  className={'card mb-2 shadow-sm border-' + priorityStyle(act.priority)}>
          <div className='card-body'>
              <div className='d-flex justify-content-between'>
               
                <h5 className='card-title'>
                  <span className='badge bg-secondary me-1'>{act.id}</span>
                 {act.title}
                </h5>
               
                <h6>
                   Priority:
                   <span className={'ms-1 text-' + priorityStyle(act.priority)}>
                   <i className={'me-1 far fa-' + priorityStyle(act.priority, true)}></i>
                  {priorityLabel(act.priority)}
                   </span>
                </h6>
              
              </div>
              <p className='card-text'>{act.description}</p>
              <div className='d-flex justify-content-end pt-2 m-0 border-top'>
              
                <button className='btn btn-sm btn-outline-primary me-2'>
                 <i className='fas fa-pen me-2'></i>
                  Edit
                </button> 
               
                <button 
                className='btn btn-sm btn-outline-danger' 
                onClick={() => deleteActivity(act.id)}>
                  <i className='fas fa-trash me-2'></i>
                  Delete
                  </button>
              </div>
          </div>
        </div>
        ))}
        
    </div>
    </>
    );
  }
  
  export default App;
  