import React from "react";
import TaskTypes from "../model/TaskTypes";
import TaskBuilder from "./items/TaskBuilder";
import LandingZone from "./items/LandingZone";

const Strip = props => {
  console.log(props);
  const { items } = props;
  return (
    <div className="strip p-small">
      {items &&
        items.map(item => {
          if (item.type === TaskTypes.LANDING_ZONE) {
            return (
              <LandingZone
                typeLanded={item.typeLanded}
                key={item.id}
                onTaskAdded={props.onTaskAdded}
                onTaskLanded={props.onTaskLanded}
                onLandingCancelled={props.onLandingCancelled}
              />
            );
          } else {
            return (
              <TaskBuilder
                {...item}
                key={item.id}
                onTaskAdded={props.onTaskAdded}
                onTaskLanded={props.onTaskLanded}
                onLandingCancelled={props.onLandingCancelled}
              />
            );
          }
        })}
    </div>
  );
};

export default Strip;
