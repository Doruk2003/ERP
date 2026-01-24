class AddTotalsAndCurrencyToOffers < ActiveRecord::Migration[8.1]
  def change
    add_column :offers, :currency, :string, null: false, default: "TRY"

    add_column :offers, :net_total,   :decimal, precision: 15, scale: 2, default: 0
    add_column :offers, :vat_total,   :decimal, precision: 15, scale: 2, default: 0
    add_column :offers, :gross_total, :decimal, precision: 15, scale: 2, default: 0
  end
end
