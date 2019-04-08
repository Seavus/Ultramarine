import React from 'react'
import PropTypes from 'prop-types'

const Input = props => {
  const { htmlFor, onChange, label, value } = props

  return (
    <div className="input-field">
      <input id={htmlFor} type="text" onChange={onChange} value={value} />
      <label htmlFor="{htmlFor}" className={value ? 'value' : ''}>
        {label}
      </label>
    </div>
  )
}

Input.propTypes = {
  label: PropTypes.string,
  htmlFor: PropTypes.string,
  value: PropTypes.string,
  onChange: PropTypes.func
}
Input.defaultProps = {
  label: '',
  htmlFor: '',
  value: '',
  onChange: () => {}
}

export default Input
