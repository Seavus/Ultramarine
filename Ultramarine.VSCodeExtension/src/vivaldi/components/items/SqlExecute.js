import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

const SqlExecute = props => {
  const { isEditable, connectionString, query, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input id="connectionString" type="text" onChange={onChange} />
          <label htmlFor="connectionString">Connection String</label>
        </div>
        <div className="input-field">
          <input id="query" type="text" onChange={onChange} />
          <label htmlFor="query">Query</label>
        </div>
      </Task>
    )
  }
  return (
    <Task {...props}>
      <p>Connection String: {connectionString}</p>
      <p>Query: {query}</p>
    </Task>
  )
}

SqlExecute.propTypes = {
  isEditable: PropTypes.bool,
  connectionString: PropTypes.string,
  query: PropTypes.string,
  onChange: PropTypes.func
}

SqlExecute.defaultProps = {
  isEditable: false,
  connectionString: '',
  query: '',
  onChange: () => {}
}

SqlExecute.type = TaskTypes.SQL_EXECUTE

export default SqlExecute
