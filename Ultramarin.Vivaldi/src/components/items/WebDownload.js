import React from 'react'
import Task from "./Task";
import TaskTypes from "../../model/TaskTypes";

const WebDownload = (props) => {
  const { isEditable, url } = props;
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input id="url" type="text" onChange={props.onChange} />
          <label htmlFor="url">URL</label>
        </div>
      </Task>
    );
  }
  else {
    return (
      <Task {...props}>
        <p>URL: {url}</p>
      </Task>
    );
  }
};

WebDownload.type = TaskTypes.WEB_DOWNLOAD

export default WebDownload;
