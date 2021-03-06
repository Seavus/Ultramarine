// This file is generated by Ultramarine and should not be modified by hand
import React, { Fragment } from 'react'
import PropTypes from 'prop-types'
import Task from '../task'
import Input from '../../ui/Input'

const WebDownload = ({
  url,
  username,
  password,
  domain,
  useSSL,
  userAgent,
  editable,
  onChange,
  ...rest
}) => (
  <Task editable={editable} {...rest} icon={WebDownload.icon}>
    {editable ? (
      <Fragment>
		<Input
          id="url"
          text="Url"
          value={url}
          onChange={onChange}
        />
		<Input
          id="username"
          text="Username"
          value={username}
          onChange={onChange}
        />
		<Input
          id="password"
          text="Password"
          value={password}
          onChange={onChange}
        />
		<Input
          id="domain"
          text="Domain"
          value={domain}
          onChange={onChange}
        />
		<Input
          id="useSSL"
          text="Use S S L"
          value={useSSL}
          onChange={onChange}
        />
		<Input
          id="userAgent"
          text="User Agent"
          value={userAgent}
          onChange={onChange}
        />
        
      </Fragment>
    ) : (
      <Fragment>
		<p>Url: {url}</p>
		<p>Username: {username}</p>
		<p>Password: {password}</p>
		<p>Domain: {domain}</p>
		<p>Use S S L: {useSSL}</p>
		<p>User Agent: {userAgent}</p>
      </Fragment>
    )}
  </Task>
)

WebDownload.description = 'Web Download'
WebDownload.icon = 'code'
WebDownload.type = 'webDownload'

WebDownload.propTypes = {
  url: PropTypes.string,
  username: PropTypes.string,
  password: PropTypes.string,
  domain: PropTypes.string,
  useSSL: PropTypes.string,
  userAgent: PropTypes.string,
  editable: PropTypes.bool,
  onChange: PropTypes.func
}

WebDownload.defaultProps = {
  url: '',
  username: '',
  password: '',
  domain: '',
  useSSL: '',
  userAgent: '',
  editable: false,
  onChange: () => {}
}

export default WebDownload
