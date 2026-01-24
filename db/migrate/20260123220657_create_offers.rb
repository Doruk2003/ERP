class CreateOffers < ActiveRecord::Migration[8.1]
  def change
    create_table :offers do |t|
      t.references :company, null: false, foreign_key: true
      t.string :offer_number, null: false
      t.date :offer_date, null: false

      # total_amount KALDIRILDI
      t.decimal :net_total,   precision: 10, scale: 2, default: 0, null: false
      t.decimal :vat_total,   precision: 10, scale: 2, default: 0, null: false
      t.decimal :gross_total, precision: 10, scale: 2, default: 0, null: false

      t.timestamps
    end

    add_index :offers, :offer_number, unique: true
  end
end
