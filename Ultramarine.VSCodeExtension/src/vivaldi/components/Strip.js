import React from 'react'
import PropTypes from 'prop-types'
import TaskTypes from '../model/TaskTypes'
import TaskBuilder from './items/TaskBuilder'
import LandingZone from './items/LandingZone'

const Strip = props => {
  const {
    items,
    onTaskAdded,
    onTaskLanded,
    onLandingCancelled,
    onFlyOver
  } = props
  return (
    <div className="strip p-small">
      {items &&
        items.map(item => {
          if (item.type === TaskTypes.LANDING_ZONE) {
            return (
              <LandingZone
                typeLanded={item.typeLanded}
                key={item.id}
                onTaskAdded={onTaskAdded}
                onTaskLanded={onTaskLanded}
                onLandingCancelled={onLandingCancelled}
              />
            )
          }

          if (Object.values(TaskTypes).includes(item.type)) {
            return (
              <TaskBuilder
                {...item}
                key={item.id}
                onTaskAdded={onTaskAdded}
                onTaskLanded={onTaskLanded}
                onLandingCancelled={onLandingCancelled}
                onFlyOver={onFlyOver}
              />
            )
          }

          return <div key={item.id}>{/* task type not found */}</div>
        })}
    </div>
  )
}

Strip.propTypes = {
  items: PropTypes.arrayOf(PropTypes.any),
  onTaskAdded: PropTypes.func,
  onTaskLanded: PropTypes.func,
  onLandingCancelled: PropTypes.func,
  onFlyOver: PropTypes.func
}

Strip.defaultProps = {
  items: [],
  onTaskAdded: () => {},
  onTaskLanded: () => {},
  onLandingCancelled: () => {},
  onFlyOver: () => {}
}

export default Strip
