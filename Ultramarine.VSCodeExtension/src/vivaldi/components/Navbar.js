import React, { Component } from 'react'
import PropTypes from 'prop-types'
import Button from './ui/Button'

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
                accept=".json"
                style={{ display: 'none' }}
                ref={this.fileOpen}
                onChange={e => {
                  handleFileChoosen(e)
                }}
              />
              <Button
                name="Open file"
                className="btn-flat"
                onClick={this.handleOpenFileClick}
              />
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
