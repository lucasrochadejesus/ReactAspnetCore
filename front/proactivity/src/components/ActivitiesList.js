import React from 'react'
import Activities from './Activities';


export default function ActivitiesList(props) {
  return (
    <div className='mt-3'>
      {props.activities.map(act => (
      <Activities 
        key={act.id}
        act={act}
        deleteActivity={props.deleteActivity}
     />
  ))}
  
    </div>
  )
}