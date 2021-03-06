import React from "react";

export default function ActivitiesForm(props) {
  return (
    <form className="row g-3">
      <div className="col-md-6">
        <label className="form-label">Id</label>
        <input
          id="id"
          type="text"
          className="form-control"
          readOnly
          value={
            Math.max.apply(
              Math,
              props.activities.map((item) => item.id)
            ) + 1
          }
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
      <div className="col-md-6">
        <label className="form-label">Title</label>
        <input id="title" type="text" className="form-control" />
      </div>
      <div className="col-md-6">
        <label className="form-label">Description</label>
        <input id="description" type="text" className="form-control" />
      </div>
      <div className="col-12">
        <button className="btn btn-outline-secondary" onClick={props.addActivity}>
          + Activity
        </button>
      </div>
    </form>
  );
}
