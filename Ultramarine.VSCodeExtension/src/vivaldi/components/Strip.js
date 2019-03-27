import React from 'react'
import PropTypes from 'prop-types'
import TaskTypes from '../model/TaskTypes'
import TaskBuilder from './items/TaskBuilder'
import LandingZone from './items/LandingZone'

const Strip = props => {
  console.log(props)
  const { items, onTaskAdded, onTaskLanded, onLandingCancelled } = props
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

          return (
            <TaskBuilder
              {...item}
              key={item.id}
              onTaskAdded={onTaskAdded}
              onTaskLanded={onTaskLanded}
              onLandingCancelled={onLandingCancelled}
            />
          )
        })}
    </div>
  )
}

Strip.propTypes = {
  items: PropTypes.arrayOf(PropTypes.any),
  onTaskAdded: PropTypes.func,
  onTaskLanded: PropTypes.func,
  onLandingCancelled: PropTypes.func
}

Strip.defaultProps = {
  items: [],
  onTaskAdded: () => {},
  onTaskLanded: () => {},
  onLandingCancelled: () => {}
}

export default Strip
