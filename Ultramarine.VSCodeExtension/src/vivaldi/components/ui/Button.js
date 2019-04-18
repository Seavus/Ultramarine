import React from 'react'
import PropTypes from 'prop-types'

const Button = ({ text, ...props }) => {
  return (
    <button type="button" {...props}>
      {text}
    </button>
  )
}

Button.propTypes = {
  text: PropTypes.string,
  className: PropTypes.string,
  onClick: PropTypes.func
}

Button.defaultProps = {
  text: '',
  className: '',
  onClick: () => {}
}

export default Button
