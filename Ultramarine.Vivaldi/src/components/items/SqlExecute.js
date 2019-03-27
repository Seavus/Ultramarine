import React from "react";
import Task from "./Task";
import TaskTypes from "../../model/TaskTypes";

const SqlExecute = (props) => {
  const { isEditable, connectionString, query } = props;
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input id="connectionString" type="text" onChange={props.onChange} />
          <label htmlFor="connectionString">Connection String</label>
        </div>
        <div className="input-field">
          <input id="query" type="text" onChange={props.onChange} />
          <label htmlFor="query">Query</label>
        </div>
      </Task>
    );
  } else {
    return (
      <Task {...props}>
        <p>Connection String: {connectionString}</p>
        <p>Query: {query}</p>
      </Task>
    );
  }
}

SqlExecute.type = TaskTypes.SQL_EXECUTE;

export default SqlExecute;
