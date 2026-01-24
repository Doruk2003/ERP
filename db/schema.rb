# This file is auto-generated from the current state of the database. Instead
# of editing this file, please use the migrations feature of Active Record to
# incrementally modify your database, and then regenerate this schema definition.
#
# This file is the source Rails uses to define your schema when running `bin/rails
# db:schema:load`. When creating a new database, `bin/rails db:schema:load` tends to
# be faster and is potentially less error prone than running all of your
# migrations from scratch. Old migrations may fail to apply correctly if those
# migrations use external dependencies or application code.
#
# It's strongly recommended that you check this file into your version control system.

ActiveRecord::Schema[8.1].define(version: 2026_01_24_180833) do
  create_schema "extensions"

  # These are extensions that must be enabled in order to support this database
  enable_extension "extensions.pg_stat_statements"
  enable_extension "extensions.pgcrypto"
  enable_extension "extensions.uuid-ossp"
  enable_extension "graphql.pg_graphql"
  enable_extension "pg_catalog.plpgsql"
  enable_extension "vault.supabase_vault"

  create_table "public.companies", force: :cascade do |t|
    t.datetime "created_at", null: false
    t.string "name"
    t.string "tax_number"
    t.datetime "updated_at", null: false
  end

  create_table "public.offer_items", force: :cascade do |t|
    t.datetime "created_at", null: false
    t.decimal "line_total", precision: 15, scale: 2, null: false
    t.bigint "offer_id", null: false
    t.bigint "product_id", null: false
    t.decimal "quantity", precision: 10, scale: 2, null: false
    t.decimal "unit_price", precision: 15, scale: 2, null: false
    t.datetime "updated_at", null: false
    t.index ["offer_id"], name: "index_offer_items_on_offer_id"
    t.index ["product_id"], name: "index_offer_items_on_product_id"
  end

  create_table "public.offers", force: :cascade do |t|
    t.bigint "company_id", null: false
    t.datetime "created_at", null: false
    t.string "currency", default: "TRY", null: false
    t.decimal "gross_total", precision: 15, scale: 2, default: "0.0"
    t.decimal "net_total", precision: 15, scale: 2, default: "0.0"
    t.date "offer_date"
    t.string "offer_number"
    t.decimal "total_amount"
    t.datetime "updated_at", null: false
    t.decimal "vat_total", precision: 15, scale: 2, default: "0.0"
    t.index ["company_id"], name: "index_offers_on_company_id"
  end

  create_table "public.products", force: :cascade do |t|
    t.boolean "active", default: true, null: false
    t.datetime "created_at", null: false
    t.string "item_type", null: false
    t.string "name", null: false
    t.decimal "price", precision: 15, scale: 2, default: "0.0", null: false
    t.datetime "updated_at", null: false
    t.decimal "vat_rate", precision: 5, scale: 2, default: "0.0", null: false
    t.index ["active"], name: "index_products_on_active"
    t.index ["item_type"], name: "index_products_on_item_type"
  end

  add_foreign_key "public.offer_items", "public.offers"
  add_foreign_key "public.offer_items", "public.products"
  add_foreign_key "public.offers", "public.companies"

end
