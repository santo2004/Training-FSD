import React from 'react';

function ProductPrice({ name, price, quantity }) {
  const total = price * quantity;

  return (
    <div className="product">
      <h4>{name}</h4>
      <p>Price: ₹{price}</p>
      <p>Quantity: {quantity}</p>
      <strong>Total: ₹{total}</strong>
    </div>
  );
}

export default ProductPrice;
