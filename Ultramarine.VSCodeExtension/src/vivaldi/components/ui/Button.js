import React from 'react'
import PropTypes from 'prop-types'

const button = props => {
  const { name, className, onClick } = props
  return (
    <button type="button" className={className} onClick={onClick}>
      {name}
    </button>
  )
}

button.propTypes = {
  name: PropTypes.string,
  className: PropTypes.string,
  onClick: PropTypes.func
}

button.defaultProps = {
  name: '',
  className: '',
  onClick: () => {}
}

export default button
