/* eslint-disable react/prop-types */
import React, { Fragment } from 'react'
import Task from './task'
import Input from '../ui/Input'

const styles = {
  backgroundColor: 'red'
}
const CreateFolder = ({ folderPath, projectName, editable, ...rest }) => (
  <Task {...rest}>
    {editable ? (
      <Fragment style={styles}>
        <Input
          id="folderPath"
          text="Path"
          value={folderPath}
          onChange={onChange}
        />
        <Input
          id="projectName"
          text="Project Name"
          value={projectName}
          onChange={onChange}
        />
      </Fragment>
    ) : (
      <Fragment>
        <p>Path: {folderPath}</p>
        <p>Project Name: {projectName}</p>
      </Fragment>
    )}
  </Task>
)

export default CreateFolder
