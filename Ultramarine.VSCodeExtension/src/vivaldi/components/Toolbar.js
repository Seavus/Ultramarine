import React from 'react'

const Toolbar = props => {
  return (
    <div className="toolbar">
      <div className="container">
        <div className="row">
          <div className="col s7 m8 offset-l1 l7 offset-xl2 xl7">
            <i className="material-icons tooltipped" data-tooltip="Open file">
              open_in_new
            </i>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Toolbar
