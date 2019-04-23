import React from 'react'
import PropTypes from 'prop-types'
import Task from './task'
import LandingZone from './landing-zone'
import taskBuilder from './task-builder'

const CompositeTask = ({ name, description, tasks }) => (
  <div className="strip p-small">
    <Task name={name} description={description}>
      {tasks.map(task => taskBuilder(task))}
      <LandingZone />
    </Task>
  </div>
)

CompositeTask.propTypes = {
  name: PropTypes.string.isRequired,
  description: PropTypes.string,
  tasks: PropTypes.array.isRequired
}

CompositeTask.defaultProps = {
  description: ''
}

export default CompositeTask
