import React from 'react'
import PropTypes from 'prop-types'
import Task from './Task'
import TaskTypes from '../../model/TaskTypes'

import Input from '../ui/Input'

const WebDownload = props => {
  const {
    isEditable,
    address,
    useDefaultCredentials,
    username,
    password,
    domain,
    onChange
  } = props
  if (isEditable) {
    return (
      <Task {...props}>
        <Input
          id="address"
          text="Address"
          value={address}
          onChange={onChange}
        />
      </Task>
    )
  }
  return (
    <Task {...props}>
      <p>Address: {address} </p>
    </Task>
  )
}

WebDownload.propTypes = {
  isEditable: PropTypes.bool,
  address: PropTypes.string,
  useDefaultCredentials: PropTypes.bool,
  username: PropTypes.string,
  password: PropTypes.string,
  domain: PropTypes.string,
  onChange: PropTypes.func
}

WebDownload.defaultProps = {
  isEditable: false,
  address: '',
  useDefaultCredentials: false,
  username: '',
  password: '',
  domain: '',
  onChange: () => {}
}

WebDownload.type = TaskTypes.WEB_DOWNLOAD

export default WebDownload
