// This file is generated by Ultramarine and should not be modified by hand
import React, { Fragment } from 'react'
import PropTypes from 'prop-types'
import Task from '../task'
import Input from '../../ui/Input'

const TextTransformation = ({
  parameters,
  fileName,
  projectName,
  editable,
  onChange,
  ...rest
}) => (
  <Task editable={editable} {...rest} icon={TextTransformation.icon}>
    {editable ? (
      <Fragment>
		<Input
          id="parameters"
          text="Parameters"
          value={parameters}
          onChange={onChange}
        />
		<Input
          id="fileName"
          text="File Name"
          value={fileName}
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
		<p>Parameters: {parameters}</p>
		<p>File Name: {fileName}</p>
		<p>Project Name: {projectName}</p>
      </Fragment>
    )}
  </Task>
)

TextTransformation.description = 'Text Transformation'
TextTransformation.icon = 'code'
TextTransformation.type = 'textTransformation'

TextTransformation.propTypes = {
  parameters: PropTypes.string,
  fileName: PropTypes.string,
  projectName: PropTypes.string,
  editable: PropTypes.bool,
  onChange: PropTypes.func
}

TextTransformation.defaultProps = {
  parameters: '',
  fileName: '',
  projectName: '',
  editable: false,
  onChange: () => {}
}

export default TextTransformation
