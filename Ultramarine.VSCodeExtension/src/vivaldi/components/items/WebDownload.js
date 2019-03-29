import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

const WebDownload = props => {
  const { isEditable, url, onChange } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <div className="input-field">
          <input id="url" type="text" onChange={onChange} />
          <label htmlFor="url">URL</label>
        </div>
      </Task>
    )
  }
  return (
    <Task {...props}>
      <p>URL: {url}</p>
    </Task>
  )
}

WebDownload.propTypes = {
  isEditable: PropTypes.bool,
  url: PropTypes.string,
  onChange: PropTypes.func
}

WebDownload.defaultProps = {
  isEditable: false,
  url: '',
  onChange: () => {}
}

WebDownload.type = TaskTypes.WEB_DOWNLOAD

export default WebDownload
