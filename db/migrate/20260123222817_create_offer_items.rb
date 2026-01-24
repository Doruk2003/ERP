class CreateOfferItems < ActiveRecord::Migration[8.1]
  def change
    create_table :offer_items do |t|
      t.references :offer,   null: false, foreign_key: true
      t.references :product, null: false, foreign_key: true

      t.string  :description, null: false
      t.decible :quantity,    precision: 10, scale: 2, null: false
      t.decimal :unit_price,  precision: 15, scale: 2, null: false
      t.decimal :line_total,  precision: 15, scale: 2, null: false

      t.timestamps
    end

    # İsteğe bağlı: offer + product kombinasyonu benzersiz olsun mu?
    # add_index :offer_items, [:offer_id, :product_id], unique: true
  end
end
