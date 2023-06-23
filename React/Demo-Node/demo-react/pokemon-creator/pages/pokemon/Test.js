import React from "react"
import Link from "next/link"

export default class Test extends React.Component{
    render(){
  return (
    <div>
      <Link href="/pokemon">
        Pokemon
      </Link>
      <br/>
      <Link href="/pokemon/list">
        Pokemon Liste
      </Link>
    </div>
  )
}
}