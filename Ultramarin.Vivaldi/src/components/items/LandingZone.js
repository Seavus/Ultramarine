import React from "react";
import TaskTypes from "../../model/TaskTypes";
import TaskBuilder from "./TaskBuilder";

const LandingZone = (props) => {
  //debugger;
  //console.log('landing zone', props);
  const { typeLanded } = props;
  const allowDragOver = e => {
    e.preventDefault();
  };
  if (typeLanded) {
    return (
      <TaskBuilder
        type={typeLanded}
        isEditable="true"
        onTaskAdded={props.onTaskAdded}
        onLandingCancelled={props.onLandingCancelled}
      />
    );
  } else {
    return (
      <div
        className="card z-depth-0 x-small task-landing-zone"
        onDrop={props.onTaskLanded}
        onDragOver={allowDragOver}
      >
        <div className="card-content">
          <p className="note center">You may drop a task here.</p>
        </div>
      </div>
    );
  }
};

LandingZone.type = TaskTypes.LANDING_ZONE;

export default LandingZone;
