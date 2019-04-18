/* eslint-disable react/react-in-jsx-scope */
import React from 'react'
import { shallow } from 'enzyme'
import Button from './Button'

describe('button render tests', () => {
  it('should be exported', () => {
    expect(Button).toBeDefined()
  })

  it('provides default props', () => {
    expect(Button.defaultProps.text).toBeDefined()
    expect(Button.defaultProps.onClick).toBeDefined()
    expect(Button.defaultProps.onClick).toBeDefined()
    expect(Button.defaultProps.onClick()).toBeUndefined()
  })

  it('renders without crashing', () => {
    shallow(<Button />)
  })

  it('renders as html button', () => {
    const wrapper = shallow(<Button />)
    const htmlButton = wrapper.find('button')
    expect(htmlButton.type()).toBe('button')
  })

  it('onClick method should be called', () => {
    const onClickMock = jest.fn()
    const wrapper = shallow(<Button onClick={onClickMock} />)
    wrapper.simulate('click')
    wrapper.update()
    expect(onClickMock.mock.calls.length).toBe(1)
  })

  it('render correctly text attribute', () => {
    const value = 'Submit'
    const wrapper = shallow(<Button text={value} />)
    expect(wrapper.html()).toContain(value)
  })
})
