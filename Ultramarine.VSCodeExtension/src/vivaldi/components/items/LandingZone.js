import React from 'react'
import PropTypes from 'prop-types'
import TaskTypes from '../../model/TaskTypes'
import TaskBuilder from './TaskBuilder'

const LandingZone = props => {
  // debugger;
  // console.log('landing zone', props);
  const {
    taskLanded,
    onTaskUpdated,
    onTaskUpdateCancelled,
    onTaskLanded
  } = props
  const allowDragOver = e => {
    e.preventDefault()
  }

  const handleTaskLanded = e => {
    const type = e.dataTransfer.getData('taskType')
    onTaskLanded(type)
  }

  if (taskLanded) {
    return (
      <TaskBuilder
        {...taskLanded}
        onTaskUpdated={onTaskUpdated}
        onTaskUpdateCancelled={onTaskUpdateCancelled}
      />
    )
  }

  return (
    <div
      className="card z-depth-0 x-small task-landing-zone"
      onDrop={handleTaskLanded}
      onDragOver={allowDragOver}
    >
      <div className="card-content">
        <p className="note center">You may drop a task here.</p>
      </div>
    </div>
  )
}

LandingZone.propTypes = {
  taskLanded: PropTypes.object,
  onTaskUpdated: PropTypes.func,
  onTaskUpdateCancelled: PropTypes.func,
  onTaskLanded: PropTypes.func
}

LandingZone.defaultProps = {
  taskLanded: null,
  onTaskUpdated: () => {},
  onTaskUpdateCancelled: () => {},
  onTaskLanded: () => {}
}

LandingZone.type = TaskTypes.LANDING_ZONE

export default LandingZone
