class CreateCompanies < ActiveRecord::Migration[8.1]
  def change
    create_table :companies do |t|
      t.string :name, null: false
      t.string :tax_number, null: false

      t.timestamps
    end

    add_index :companies, :tax_number, unique: true
  end
end
