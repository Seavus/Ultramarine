import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

import Input from '../ui/Input'

const SqlExecute = props => {
  const { isEditable, connectionString, query, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <Input
          label="Connection String"
          htmlFor="connectionString"
          value={connectionString}
          onChange={onChange}
        />
        <Input
          label="Query"
          htmlFor="query"
          value={query}
          onChange={onChange}
        />
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
