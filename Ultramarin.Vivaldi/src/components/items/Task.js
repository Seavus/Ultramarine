import React from "react";

const Task = (props) => {
  //debugger;
  //console.log('task', props);
  const { name, description, isEditable, children } = props;
  if (isEditable)
  {
    return (
      <div className="card z-depth-0">
        <div className="card-content">
          <div className="input-field">
            <input id="name" type="text" onChange={props.onChange} />
            <label htmlFor="name">Name</label>
          </div>
          <div className="input-field">
            <input id="description" type="text" onChange={props.onChange} />
            <label htmlFor="description">Description</label>
          </div>
          {children}
        </div>
        <div className="card-action right-align">
          <button className="waves-effect waves-light btn grey mlr-small" onClick={props.onLandingCancelled}>Cancel</button>
          <button className="waves-effect waves-light btn" onClick={props.onTaskAdded}>Submit</button>
        </div>
      </div>
    )
  }
  else
  {
    return (
      <div className="card z-depth-0">
        <div className="card-content">
          <span className="card-title text-capitalize">{name}</span>
          <p className="mb-small">{description}</p>
          {children}
        </div>
      </div>
    );
  }
};

export default Task;
