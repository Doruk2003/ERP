class CreateProducts < ActiveRecord::Migration[8.1]
  def change
    create_table :products do |t|
      t.string  :name, null: false

      # product | service
      t.string  :item_type, null: false

      # default sales price
      t.decimal :unit_price, precision: 15, scale: 2, null: false

      # VAT / KDV rate (e.g. 20.00)
      t.decimal :vat_rate, precision: 5, scale: 2, default: 0, null: false

      # soft usage control
      t.boolean :active, default: true, null: false

      t.timestamps
    end

    add_index :products, :item_type
    add_index :products, :active
  end
end
