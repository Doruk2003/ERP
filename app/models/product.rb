class Product < ApplicationRecord
  has_many :offer_items, dependent: :destroy

  validates :name, presence: true
  validates :price, numericality: { greater_than_or_equal_to: 0 }
  validates :vat_rate, numericality: { greater_than_or_equal_to: 0 }
  validates :item_type, inclusion: { in: %w[product service] }
  validates :active, inclusion: { in: [ true, false ] }
end
