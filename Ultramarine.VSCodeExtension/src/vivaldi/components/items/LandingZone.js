import React from 'react'
import PropTypes from 'prop-types'
import TaskTypes from '../../model/TaskTypes'
import TaskBuilder from './TaskBuilder'

const LandingZone = props => {
  // debugger;
  // console.log('landing zone', props);
  const { typeLanded, onTaskAdded, onLandingCancelled, onTaskLanded } = props
  const allowDragOver = e => {
    e.preventDefault()
  }
  if (typeLanded) {
    return (
      <TaskBuilder
        type={typeLanded}
        isEditable
        onTaskAdded={onTaskAdded}
        onLandingCancelled={onLandingCancelled}
      />
    )
  }

  return (
    <div
      className="card z-depth-0 x-small task-landing-zone"
      onDrop={onTaskLanded}
      onDragOver={allowDragOver}
    >
      <div className="card-content">
        <p className="note center">You may drop a task here.</p>
      </div>
    </div>
  )
}

LandingZone.propTypes = {
  typeLanded: PropTypes.oneOf([
    TaskTypes.CREATE_FOLDER,
    TaskTypes.SQL_EXECUTE,
    TaskTypes.WEB_DOWNLOAD,
    TaskTypes.GENERATE_CODE_FROM_T4_TEMPLATE,
    TaskTypes.COMPOSITE
  ]),
  onTaskAdded: PropTypes.func,
  onLandingCancelled: PropTypes.func,
  onTaskLanded: PropTypes.func
}

LandingZone.defaultProps = {
  typeLanded: null,
  onTaskAdded: () => {},
  onLandingCancelled: () => {},
  onTaskLanded: () => {}
}

LandingZone.type = TaskTypes.LANDING_ZONE

export default LandingZone
