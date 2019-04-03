import React, { Component } from 'react'
import PropTypes from 'prop-types'

class Navbar extends Component {
  constructor(props) {
    super(props)
    this.fileOpen = React.createRef()
  }

  handleOpenFileClick = () => {
    // console.log('file open click')
    // debugger
    this.fileOpen.current.click()
  }

  render() {
    const { handleFileChoosen } = this.props
    return (
      <nav>
        <div className="nav-wrapper">
          <a href="." className="brand-logo text-uppercase plr-small">
            Ultramarine
          </a>
          <ul id="nav-mobile" className="right hide-on-med-and-down">
            <li>
              <input
                type="file"
                style={{ display: 'none' }}
                ref={this.fileOpen}
                onChange={e => {
                  handleFileChoosen(e)
                }}
              />
              <button
                className="btn-flat"
                type="button"
                onClick={this.handleOpenFileClick}
              >
                Open file
              </button>
            </li>
          </ul>
        </div>
      </nav>
    )
  }
}

Navbar.propTypes = {
  handleFileChoosen: PropTypes.func
}

Navbar.defaultProps = {
  handleFileChoosen: () => {}
}

export default Navbar
