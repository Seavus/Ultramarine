import React from 'react'
import PropTypes from 'prop-types'

const Input = props => {
  const { htmlFor, onChange, text, value } = props

  return (
    <div className="input-field">
      <input id={htmlFor} type="text" onChange={onChange} value={value} />
      <label htmlFor="{htmlFor}" className={value ? 'value' : ''}>
        {text}
      </label>
    </div>
  )
}

Input.propTypes = {
  text: PropTypes.string,
  htmlFor: PropTypes.string,
  value: PropTypes.string,
  onChange: PropTypes.func
}
Input.defaultProps = {
  text: '',
  htmlFor: '',
  value: '',
  onChange: () => {}
}

export default Input
