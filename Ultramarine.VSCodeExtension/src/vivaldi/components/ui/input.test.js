import React from 'react'
import { shallow } from 'enzyme'
import Input from './Input'

describe('input component test', () => {
  it('should be exported', () => {
    expect(Input).toBeDefined()
  })

  it('provides default props', () => {
    expect(Input.defaultProps.text).toBeDefined()
    expect(Input.defaultProps.value).toBeDefined()
    expect(Input.defaultProps.htmlFor).toBeDefined()
    expect(Input.defaultProps.onChange).toBeDefined()
    expect(Input.defaultProps.onChange()).toBeUndefined()
  })

  it('renders without crashing', () => {
    shallow(<Input />)
  })

  it('renders input type text properly', () => {
    const wrapper = shallow(<Input />)
    const text = wrapper.find({ type: 'text' })
    expect(text.type()).toBe('input')
  })

  it('onChange method should be called', () => {
    const onChangeMock = jest.fn()
    const wrapper = shallow(<Input onChange={onChangeMock} />)
    wrapper.find({ type: 'text' }).simulate('change')
    expect(onChangeMock.mock.calls.length).toBe(1)
  })

  it('render correctly text atribute', () => {
    const text = 'description'
    const wrapper = shallow(<Input text={text} />)
    expect(wrapper.html()).toContain(text)
  })
})
