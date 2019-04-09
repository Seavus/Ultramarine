import React from 'react'
import PropTypes from 'prop-types'

const checkbox = props => {
  const { id, name, className, onChange, overwrite } = props
  return (
    <label>
      <input
        id={id}
        type="checkbox"
        className={className}
        onChange={onChange}
        checked={overwrite}
      />
      <span>{name}</span>
    </label>
  )
}

checkbox.propTypes = {
  id: PropTypes.string,
  name: PropTypes.string,
  className: PropTypes.string,
  overwrite: PropTypes.bool,
  onChange: PropTypes.func
}

checkbox.defaultProps = {
  id: '',
  name: '',
  className: '',
  overwrite: false,
  onChange: () => {}
}

export default checkbox
