import React from "react";
import Task from "./Task";
import TaskTypes from "../../model/TaskTypes";

const CreateFolder = (props) => {
  //console.log('create folder', this.props);
  const { isEditable, path } = props;
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input id="path" type="text" onChange={props.onChange} />
          <label htmlFor="path">Path</label>
        </div>
      </Task>
    );
  } else {
    return (
      <Task {...props}>
        <p>Path: {path}</p>
      </Task>
    );
  }
}

CreateFolder.type = TaskTypes.CREATE_FOLDER;

export default CreateFolder;
