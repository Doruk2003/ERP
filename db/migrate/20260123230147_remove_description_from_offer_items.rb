class RemoveDescriptionFromOfferItems < ActiveRecord::Migration[8.1]
  def change
    remove_column :offer_items, :description, :string
  end
end
