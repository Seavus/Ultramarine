import React from 'react'
import PropTypes from 'prop-types'

const Checkbox = ({ text, ...props }) => {
  return (
    <label>
      <input type="checkbox" {...props} />
      <span>{text}</span>
    </label>
  )
}

Checkbox.propTypes = {
  id: PropTypes.string,
  text: PropTypes.string,
  className: PropTypes.string,
  checked: PropTypes.bool,
  onChange: PropTypes.func
}

Checkbox.defaultProps = {
  id: '',
  text: '',
  className: '',
  checked: false,
  onChange: () => {}
}

export default Checkbox
