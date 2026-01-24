class RemoveUnitPriceFromProducts < ActiveRecord::Migration[8.1]
  def change
    remove_column :products, :unit_price, :decimal
  end
end
