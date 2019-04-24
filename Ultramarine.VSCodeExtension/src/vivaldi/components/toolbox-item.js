/* eslint-disable jsx-a11y/interactive-supports-focus */
/* eslint-disable jsx-a11y/click-events-have-key-events */
import React, { Component } from 'react'
import PropTypes from 'prop-types'

class ToolboxItem extends Component {
  handleClick = () => {
    const { onClick, name } = this.props
    onClick(name)
  }

  handleDragStart = e => {
    const { type } = this.props
    e.dataTransfer.setData('taskType', type)
  }

  render() {
    const { description, icon, onDragEnd } = this.props
    return (
      <div
        className="d-ib plr-small"
        role="button"
        draggable
        onClick={this.handleClick}
        onDragStart={this.handleDragStart}
        onDragEnd={onDragEnd}
      >
        <i className="material-icons tooltipped" data-tooltip={description}>
          {icon}
        </i>
      </div>
    )
  }
}

ToolboxItem.propTypes = {
  type: PropTypes.string.isRequired,
  name: PropTypes.string.isRequired,
  description: PropTypes.string,
  icon: PropTypes.string,
  onClick: PropTypes.func.isRequired,
  onDragEnd: PropTypes.func.isRequired
}

ToolboxItem.defaultProps = {
  description: '',
  icon: 'cog'
}

export default ToolboxItem
