import React from 'react';

function ProductPrice(props) {
  const total = props.rate * props.quantity;

  return (
    <div className="product">
      <h4>{props.name}</h4>
      <p>Price: Rs.{props.rate}</p>
      <p>Quantity: {props.quantity}</p>
      <strong>Total: Rs.{total}</strong>
    </div>
  );
}

export default ProductPrice;
