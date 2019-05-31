import React from 'react'
import { shallow } from 'enzyme'
import Checkbox from './Checkbox'

describe('checkbox render test', () => {
  it('should be exported', () => {
    expect(Checkbox).toBeDefined()
  })

  it('provides default props', () => {
    expect(Checkbox.defaultProps.id).toBeDefined()
    expect(Checkbox.defaultProps.text).toBeDefined()
    expect(Checkbox.defaultProps.className).toBeDefined()
    expect(Checkbox.defaultProps.checked).toBe(false)
    expect(Checkbox.defaultProps.onChange).toBeDefined()
    expect(Checkbox.defaultProps.onChange()).toBeUndefined()
  })

  it('renders without crashing', () => {
    shallow(<Checkbox />)
  })

  it('renders input type checkbox properly', () => {
    const wrapper = shallow(<Checkbox />)
    const checkbox = wrapper.find({ type: 'checkbox' })
    expect(checkbox.type()).toBe('input')
  })

  it('onChange method should be called', () => {
    const onChangeMock = jest.fn()
    const wrapper = shallow(<Checkbox onChange={onChangeMock} />)
    wrapper.find({ type: 'checkbox' }).simulate('change')
    expect(onChangeMock.mock.calls.length).toBe(1)
  })

  it('render correctly text atribute', () => {
    const text = 'overwrite'
    const wrapper = shallow(<Checkbox text={text} />)
    expect(wrapper.html()).toContain(text)
  })
})
