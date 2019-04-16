import React from 'react'
import PropTypes from 'prop-types'

const Button = ({ text, ...props }) => {
  // const { text, className, onClick } = props
  // className={className} onClick={onClick}>
  return (
    <button type="button" {...props}>
      {text}
    </button>
  )
}

Button.propTypes = {
  text: PropTypes.string,
  onClick: PropTypes.func
}

Button.defaultProps = {
  text: '',
  onClick: () => {}
}

export default Button
