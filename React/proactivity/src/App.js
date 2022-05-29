import './App.css';
import { useState } from 'react';
import ActivitiesForm from './components/ActivitiesForm';
import ActivitiesList from './components/ActivitiesList';

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
    setActivities([...actFilter])
     
  }

 
  return (
    <>
    <ActivitiesForm 
     addActivity={addActivity}
     activities={activities}
    />
    <ActivitiesList 
      activities={activities}
      deleteActivity={deleteActivity}
    />
    </>
    );
  }
  
  export default App;
  